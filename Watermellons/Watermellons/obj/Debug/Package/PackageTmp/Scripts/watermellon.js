$(document).ready(function () {
    $('#email-validation-message').hide();
    $('#TermsAndConditionsAccepted').attr('checked', false);
    checkDuplicateEmail();
    checkWordCount();

    $('#Email').blur(checkDuplicateEmail);

    function checkDuplicateEmail(){
        let emailAddress = $('#Email').val();

        if(emailAddress !== '')
        {
            let URL = 'watermellon/IsAlreadyEntered';
            let successFn = function (data) {
                if (data.Result === true) {
                    $('#email-validation-message').show();
                }
                else {
                    $('#email-validation-message').hide();
                }
            }

            $.ajax({
                type: "POST",
                url: URL,
                data: { email: emailAddress },
                success: successFn,
                dataType: 'json'
            });
        }
        else
        {
            $('#email-validation-message').hide();
        }
    }


    $('#FavouriteWatermellonPlace').keyup(checkWordCount);

    function checkWordCount() {
        let enteredText = $('#FavouriteWatermellonPlace').val();
        let words = enteredText.trim().split(' ').filter(function (value) {
            return value !== "";
        });

        if (words.length > 0) {
            $('#favorite-place-message-count').addClass("text-info");
            $('#favorite-place-message-count').removeClass("text-danger");

            $('#favorite-place-message-count').show();
            if (words.length > 100) {
                $('#favorite-place-message-count').removeClass("text-info");
                $('#favorite-place-message-count').addClass("text-danger");
                wordCountMessage = "You have entered too many words. Max 100";
            }
            else {
                wordCountMessage = "Word count: " + words.length + " of 100";
            }

            $('#favorite-place-message-count').text(wordCountMessage);
        }
        else {
            $('#favorite-place-message-count').hide();
        }
    }


    $('#TermsAndConditionsAccepted').change(function () {
        let checkedValue = $('#TermsAndConditionsAccepted').is(':checked')
        if(checkedValue === true)
        {
            $('#submit-button').prop('disabled', false);
        }
        else
        {
            $('#submit-button').prop('disabled', true);
        }
    })

    /*
    $(window).resize(function () {
        let w = $(window).width();
        console.log(w);
    });
    */
});