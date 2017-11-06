    $(document).on("click", ".redirect", function () {
        var $row = $(this).closest('tr');
    
        var $trackId = $row.find('.trackId').text();
        var $trackName = $row.find('.trackName').text();
        var $artistName = $row.find('.artist').text();
        var $category = $row.find('.category').text();
        var $trackUrl = $row.find('.trackUrl').text();
        var $details = { trackId: $trackId, trackName: $trackName, artistName: $artistName, category: $category };

        $.ajax({
            url: "/Home/UpdateAndRedirect",
            type: "post",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify($details),
            dataType: "text",
            success: function (data) {
                window.open($trackUrl);
            },
            error: function () {
                alert("in error");
            }
        });
    });