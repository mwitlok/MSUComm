"use strict";

$('#directedList').on('click', { listID: ".directedList" }, rollDownList);
$('#producedList').on('click', { listID: ".producedList" }, rollDownList);
$('#actedList').on('click', { listID: ".actedList" }, rollDownList);


function rollDownList(event)
{
	$(event.data.listID).slideToggle();
}