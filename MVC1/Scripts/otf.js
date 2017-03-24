
$(function () {

    var ajaxFormSubmit = function () {
            var $form = $(this);

            var options = {
                url: $form.attr("action"),
                type: $form.attr("method"),
                data: $form.serialize()
            }

            $.ajax(options).done(function (data) {
                var $target = $($form.attr("data-otf-target"));
                var $newHtml = $(data);
                $target.replaceWith($newHtml);
                $newHtml.effect("highlight");
            });

            return false; //dont allow the normal browser response
                          //of going back to server and redrawing full page
    };

    var SubmitFormAfterAutoComplete = function (event, ui) {
        var $input = $(this);
        $input.val(ui.item.label);

        var $form = $input.parents("form:first");
        $form.submit();
    };





    var createQuickSearch = function () {
        var $input = $(this);
        var options = {
            source: $input.attr("data-otf-quicksearch"),
            select: SubmitFormAfterAutoComplete
        }

        $input.autocomplete(options);
    }

    /*************************************************************************/
    /** The wiring line of code at the bottom of this file, refers to       **/
    /** getPage. It also includes                                           **/
    /** a filter, which should result in 'this' being one of the paging tags.*/
    /**                                                                     **/
    /*************************************************************************/
    var getPage = function () {
        var $a = $(this);


        var options = {
            url: $a.attr("href"),       //pull the desired url out of the paging tag
            data: $("form").serialize(),// so that we know what url to go to with ajax.
            type: "get"                 //isnt that intuitive? ??
        };

        $.ajax(options).done(function (data) {
            var target = $a.parents("div.pagedList").attr("data-otf-target");
            $(target).replaceWith(data);
        });

        return false;
    }

    /*************************************************************************/
    /** wiring code, which attaches DOM elements to the funtions above.     **/
    /**                                                                     **/
    /*************************************************************************/

    $("form[data-otf-ajax='true'").submit(ajaxFormSubmit);
    //DOM ready event
      //use this 'selector' to identify any form matching the condition.
        //select any form where there is a data-otf-ajax attribute set to true
                                  //lock on to the submit event for a matching form
                                        //call the function ajaxFormSubmit instead
                                        //of going back to server


    $("input[data-otf-quicksearch]").each(createQuickSearch);

    $(".body-content").on("click", ".pagedList a", getPage);


});