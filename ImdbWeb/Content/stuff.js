$(document).ready(
    function () {
        $('#findMovie').click(
            function ()
            {
                var movieName = $('#searchBox').val();
                $.getJSON('http://www.omdbapi.com/?s=' + movieName + '&r=json',
                    function (data)
                    {
                        $("#resultList").empty();
                        $("#movieResults").css("display", "block");
                        $.each(data.Search,
                            function (i, item)
                            {
                                $("#resultList").append('<tr><td onclick="addMovie(\'' + item.imdbID + '\')" ><u>' + item.Title + '</u></td><td>' + item.Year + '</td></tr>');
                            });
                    });
            });
    });

function addMovie(id)
{
    $.getJSON('http://www.omdbapi.com/?i=' + id + '&r=json',
        function (data)
        {
            if(data.Plot != "")
            {
                $('#desc').val(data.Plot);
            }
            if(data.Year != "")
            {
                $('#prodYear').val(data.Year);
            }
            if(data.Runtime != "")
            {
                var runt = parseInt(data.Runtime, 10);
                $('#runHour').val(Math.floor(runt / 60));
                $('#runMin').val(runt % 60);
            }
            if(data.Title != "")
            {
                $('#title').val(data.Title);
                $('#origTitlte').val(data.Title);
            }
        });
}