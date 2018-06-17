var previewEventModule = (function () {
    var $eventContainer = null,
        $eventStartTime = null,
        $odds = null;

    function loadElements() {
        $eventsContainer = $('.event-container');
        $odd = $eventsContainer.find('.odd');
        checkEventExperation();
    }

    function loadEvents() {
        $odd.on('click', printInConsole)
    }

    function init() {
        loadElements();
        loadEvents();
    }

    function printInConsole() {
        var eventId = $(this).parent().find('#event-id').text().trim();
        var oddName = $(this).attr('id');
        var oddValue = $(this).text().trim();

        console.log(eventId + ' ' + oddName + ' ' + oddValue);
    }


    function checkEventExperation() {
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