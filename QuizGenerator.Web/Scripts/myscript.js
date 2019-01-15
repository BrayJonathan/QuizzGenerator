$(document).ready(function () {
    var cpt = 0;

    $('.datepicker').datepicker({
        format: 'dd/mm/yyyy'
    });

    $('#AddQuestionOption').on('click', function () {
        AddQuestionOptionDiv();
    });

    $('#validate').on('click', function (e) {
        e.preventDefault();
        Validate();
    });

    function AddQuestionOptionDiv() {
        cpt += 1;
        var div = $('#QuestionOption_').clone();
        //display div
        div.css('visibility', 'visible');
        div.css('display', 'block');

        //change id div
        div.attr('id', 'QuestionOption_' + cpt);

        //change rank of span question
        div.find('.question').text('Question ' + cpt + ' :');

        //change rank of input
        div.find('textarea').attr('id', 'label_' + cpt);
        div.find('input[type=checkbox]').attr('id', 'checkbox_' + cpt);

        //change rank of delete button
        var btn = div.find('.btn');
        btn.attr('id', 'delete_' + cpt);

        //add click event on delete button
        var id = btn.attr('id').substring(7, 8);
        btn.on('click', function () {
            RemoveQuestionOpiton(id);
        });

        //add div
        $('#QuestionOptions').append(div);
    }

    function RemoveQuestionOpiton(id) {
        $('#QuestionOption_' + id).remove();
    }

    function Validate() {
        var str = '';
        for (i = 1; i <= cpt; i++) {
            if (typeof($('#label_'+i).val()) !== 'undefined') {
                str += $('#label_' + i).val() + ' id = ' + i + '\n\r';
            }
        }
        alert(str);
    }
});
