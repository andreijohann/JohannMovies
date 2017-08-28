/*
jQuery(function ($) {
    $.validator.addMethod('date',
        function (value, element) {
            $.culture = Globalize.culture("en-AU");
            var date = Globalize.parseDate(value, "dd/MM/yyyy", "en-AU");
            return this.optional(element) ||
                !/Invalid|NaN/.test(new Date(date).toString());
        });
});
*/