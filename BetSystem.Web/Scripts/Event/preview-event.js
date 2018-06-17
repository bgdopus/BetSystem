var previewEventModule = (function () {
    var $eventContainer = null,
        $eventStartTime = null;

    function loadElements() {
        $eventsContainer = $('.event-container');

        checkEventExperation();
    }

    function loadEvents() {
    }

    function init() {
        loadElements();
        loadEvents();
    }

    function checkEventExperation() {
        debugger;
        for (var i = 0; i < $eventsContainer.length; i++) {
            var dateStr = $($eventsContainer[i]).find('.event-start-time').html().trim();
            var date = Date.parse(dateStr);
            var currentDate = Date.parse(new Date())
            if (date < currentDate) {
                $($eventsContainer[i]).addClass('expired');
            } 
        }
    }
    

    return {
        init: init
    };
}());

$(document).ready(function () {
    previewEventModule.init();
});