// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
// drag and drop sort
$(function () {
    $("#sortable").sortable({
        stop: function (event, ui) {
            $("#sortable tr .seq").each(function (i, el) {
                $(el).val(i);
            });
        }
    })
})
// add message row
$('#AddRow').click(function () {
    var i;
    i = $('tr.MsgRow').last().index();
    i = i+1;
    
    $.ajax({
        url: 'Edit?handler=row&seqNum=' + i + '&storyId=' + $('#Story_ID').val(),
        success: function (data) {
            $(data).insertAfter($('tr.MsgRow').last());
            //console.log(data)
            $("form").removeData("validator");
            $("form").removeData("unobtrusiveValidation");
            $.validator.unobtrusive.parse($("form"));
            //$("form").validate();
        },
        error: function (a, b, c) {
            console.log(a, b, c);
        }
    });
});