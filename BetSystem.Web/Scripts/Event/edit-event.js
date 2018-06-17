var editEventModule = (function () {
    var $body = null,
        $deleteBtn = null,
        $editBtn = null;

    function loadElements() {
        $body = $('body');
        $deleteBtn = $('.deleteBtn');
        $editBtn = $('.editBtn');
    }

    function loadEvents() {
        $editBtn.on('click', updateEvent);
        $deleteBtn.on('click', updateEvent);
    }

    function init() {
        loadElements();
        loadEvents();
    }

    function updateEvent() {
        var target = $(this).html().trim();
        var $eventContainer = $(this).parent();
        var id = parseInt($eventContainer.find('.id').text().trim());
        var eventName = $eventContainer.find('#EventName').val();
        var oddsForFirstTeam = parseFloat($eventContainer.find('#OddsForFirstTeam').val());
        var oddsForDraw = parseFloat($eventContainer.find('#OddsForDraw').val());
        var oddsForSecondTeam = parseFloat($eventContainer.find('#OddsForSecondTeam').val());
        var eventStartDate = new Date(Date.parse($eventContainer.find('#EventStartDate').val()));
        var isDeleted = false;

        if (oddsForFirstTeam < 1 || oddsForDraw < 1 || oddsForSecondTeam < 1) {
            alert('Odd must be greater or equal to 1!');
            return;
        }

        if (target == 'Delete') {
            isDeleted = true;
        }
        
        var data = {
            Id : id,
            EventName : eventName,
            OddsForFirstTeam : oddsForFirstTeam,
            OddsForDraw : oddsForDraw,
            OddsForSecondTeam : oddsForSecondTeam,
            EventStartDate: eventStartDate,
            IsDeleted : isDeleted
        }

        $.ajax({
            url: '/Home/UpdateEvent',
            type: 'POST',
            data: JSON.stringify(data),
            processData: true,
            contentType: "application/json",
            dataType: "json",
            success: function (result) {
                alert(result.message);
            }
        });
        
    }
    

    function onSuccess(message) {
        if (Array.isArray(message)) {
            var errors = '';
            for (var i = 0; i < message.length; i += 1) {
                errors += '<p>' + message[i].ErrorMessage + '</p>';
            }
            mainContent.showErrorPopup(errors);
            $('#triggers-container .shown *').prop("disabled", true);
        } else {
            mainContent.showSuccessPopup('Popup created successful!');
            //clean all field values
            $('.sub-menu-popupsender.active').trigger('click', ['popupCreated']);
        }

        kendo.ui.progress($body, false);

        var ajaxLoadingFinished = false;
        triggers.setStateOfAjaxLoading(ajaxLoadingFinished);
    }

    return {
        init: init,
        onSuccessNotify: onSuccess
    };
}());

$(document).ready(function () {
    editEventModule.init();
});