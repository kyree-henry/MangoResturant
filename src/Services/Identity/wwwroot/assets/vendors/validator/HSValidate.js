const validators = {
    "data-hs-validation-equal-field": t => {
        const e = document.querySelector(t.getAttribute("data-hs-validation-equal-field"));
        t.addEventListener("input", i => {
            e.value.toString().toLocaleLowerCase() !== i.target.value.toString().toLocaleLowerCase() ?
                t.setCustomValidity("qual-field") : t.setCustomValidity("");
            HSBsValidation.updateFieldStete(t);
        });
        e.addEventListener("input", e => {
            t.value.toString().toLocaleLowerCase() !== e.target.value.toString().toLocaleLowerCase() ?
                t.setCustomValidity("qual-field") : t.setCustomValidity("");
            HSBsValidation.updateFieldStete(t);
        });
    }
};

const HSBsValidation = {
    init: (t, e) => {
        var i = document.querySelectorAll(t);
        return Array.prototype.slice.call(i).forEach(t => {
            for (const e in validators)
                Array.prototype.slice.call(t.querySelectorAll(`[${e}]`)).forEach(validators[e]);
            this.addVlidationListners(t.elements);
            t.addEventListener("submit", i => {
                t.checkValidity() ?
                    this.onSubmit({ event: i, form: t, options: e }) :
                    (i.preventDefault(), i.stopPropagation(), this.checkFieldsState(t.elements));
                t.classList.add("was-validated");
            }, !1);
        }), this;
    },
    addVlidationListners: t => {
        Array.prototype.slice.call(t).forEach(t => {
            const e = t.closest("[data-hs-validation-validate-class]");
            e && (
                t.addEventListener("input", t => this.updateFieldStete(t.target)),
                t.addEventListener("focus", t => e.classList.add("focus")),
                t.addEventListener("blur", t => e.classList.remove("focus"))
            );
        });
    },
    checkFieldsState: t => {
        Array.prototype.slice.call(t).forEach(t => this.updateFieldStete(t));
    },
    updateFieldStete: t => {
        const e = t.closest("[data-hs-validation-validate-class]");
        e && (
            t.checkValidity() ?
                (e.classList.add("is-valid"), e.classList.remove("is-invalid")) :
                (e.classList.add("is-invalid"), e.classList.remove("is-valid"))
        );
    },
    onSubmit: t => {
        return !(!t.options || typeof t.options.onSubmit !== "function") && t.options.onSubmit(t);
    }
};
