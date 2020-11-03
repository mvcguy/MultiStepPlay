
function getMultiStepConfig() {
    return {
        rootElement: '#msCreateNew'
    };
}

var sourceType = { 'navigation': 0, 'next': 1, 'previous': 2 };

$(document).ready(function () {

    $(".previous").on('click', function (e) {
        e.preventDefault();
        UpdateView(e.target);
    });

    $(".next").on('click', function (e) {
        e.preventDefault();
        UpdateView(e.target)
    });

    $("div[data-target]").on('click', function (e) {
        e.preventDefault();
        UpdateView(e.currentTarget);
    });

    //$(".completed").on('click', function (e) {
    //    e.preventDefault();
    //    console.log('completed');

    //});

    function canGoNext(currentStep, next, previous) {
        if (next && next.length > 0 && next.attr('id') != currentStep.attr('id')
            && currentStep.hasClass('end') === false) return true;

        return false;
    }

    function canGoPrevious(currentStep, next, previous) {
        if (previous && previous.length > 0 && previous.attr('id') != currentStep.attr('id')
            && currentStep.hasClass('start') === false) return true;

        return false;
    }

    function handleNavigationButtons(rootElement) {

        //
        // enable/disable buttons
        //
        var currentCard = rootElement.find('.card-focus');
        var nextCard = currentCard.next('.cardx');
        var previousCard = currentCard.prev('.cardx');
        var canGoNextt = canGoNext(currentCard, nextCard, previousCard);
        var canGoPreviouss = canGoPrevious(currentCard, nextCard, previousCard)

        if (!canGoNextt) {
            $(".next").addClass('disabled');
        }
        else {
            $(".next").removeClass('disabled');
        }

        if (!canGoPreviouss) {
            $(".previous").addClass('disabled');
        }
        else {
            $(".previous").removeClass('disabled');
        }

        //
        // choose navigation step
        //
        var currentStep = rootElement.find('.step-focus');
        var navigationStep = $(rootElement).find('[data-target="#' + currentCard.attr('id') + '"]')
        currentStep.removeClass('step-focus');
        navigationStep.addClass("step-focus");

        //
        // handle completed button visibility
        //
        var isLastCard = currentCard && currentCard.length > 0 && currentCard.hasClass('end') === true;
        if (isLastCard) {
            $('.completed').show();
            $('.next').hide();
        }
        else {
            $('.completed').hide();
            $('.next').show();
        }
    }

    function UpdateView(source) {

        var that = $(source)

        var srcType = sourceType.navigation;

        if (that.hasClass('previous'))
            srcType = sourceType.previous;
        if (that.hasClass('next'))
            srcType = sourceType.next;

        var pageConfig = getMultiStepConfig();
        var rootElement = $(pageConfig.rootElement);

        var currentCard = rootElement.find('.card-focus');
        var nextCard = currentCard.next('.cardx');
        var previousCard = currentCard.prev('.cardx');

        if (srcType === sourceType.next && nextCard && nextCard.length > 0) {
            currentCard.hide();
            nextCard.show();
            nextCard.addClass('card-focus');
            currentCard.removeClass('card-focus');
        }

        if (srcType === sourceType.previous && previousCard && previousCard.length > 0) {
            currentCard.hide();
            previousCard.show();
            previousCard.addClass('card-focus');
            currentCard.removeClass('card-focus');
        }

        if (srcType === sourceType.navigation) {

            var dataTarget = that.data('target');
            var selectedCard = $(dataTarget);

            if (selectedCard.attr('id') !== currentCard.attr('id')) {
                selectedCard.show();
                currentCard.hide();

                selectedCard.addClass('card-focus');
                currentCard.removeClass('card-focus');
            }
        }

        handleNavigationButtons(rootElement);
    }
});
