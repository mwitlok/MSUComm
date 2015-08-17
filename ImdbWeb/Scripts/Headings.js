
$(function ()
{
    $('.directedList').on('click', rollDownList('.directedList'))
}) 

function rollDownList(className)
{ 
    $(className + "").slideToggle();
}