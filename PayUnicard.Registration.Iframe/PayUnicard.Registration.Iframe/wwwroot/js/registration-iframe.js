window.registrationIframe = (() => {
    const listeners = new Map();

    function normalizeOrigins(origins) {
        return Array.isArray(origins) ? origins.filter(Boolean) : [];
    }

    function isAllowedOrigin(origin, allowedOrigins) {
        if (!allowedOrigins.length) {
            return true;
        }

        return allowedOrigins.includes(origin);
    }

    return {
        notifyParent(eventName, payload, allowedOrigins) {
            if (window.parent === window || !eventName) {
                return;
            }

            const targetOrigins = normalizeOrigins(allowedOrigins);
            const message = {
                source: "PayUnicard.Registration.Iframe",
                eventName,
                payload: payload ? JSON.parse(payload) : null
            };

            if (!targetOrigins.length) {
                window.parent.postMessage(message, "*");
                return;
            }

            targetOrigins.forEach(origin => window.parent.postMessage(message, origin));
        },

        async getRecaptchaToken(siteKey, action) {
            if (!siteKey || !window.grecaptcha || !window.grecaptcha.execute) {
                return "";
            }

            return await window.grecaptcha.execute(siteKey, { action: action || "submit" });
        },

        registerKycListener(dotNetRef, allowedOrigins, completionEventNames) {
            const id = crypto.randomUUID();
            const origins = normalizeOrigins(allowedOrigins);
            const eventNames = Array.isArray(completionEventNames) ? completionEventNames : [];

            const handler = async event => {
                if (!isAllowedOrigin(event.origin, origins)) {
                    return;
                }

                const data = event.data || {};
                const eventName = data.eventName || data.type || "";
                const completed =
                    data.completed === true ||
                    data.status === "completed" ||
                    data.status === "success" ||
                    eventNames.includes(eventName);

                if (!completed) {
                    return;
                }

                await dotNetRef.invokeMethodAsync("HandleKycMessage", event.origin, eventName);
            };

            window.addEventListener("message", handler);
            listeners.set(id, handler);
            return id;
        },

        removeKycListener(id) {
            const handler = listeners.get(id);
            if (!handler) {
                return;
            }

            window.removeEventListener("message", handler);
            listeners.delete(id);
        }
    };
})();
