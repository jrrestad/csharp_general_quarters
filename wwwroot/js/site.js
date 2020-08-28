// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

$( document ).ready(function() {
    // console.log( "ready!" );
    $(".enemyMap").mousemove(function(event){
        var X = event.pageX - $(this).offset().left;
        var Y = event.pageY - $(this).offset().top;
        // console.log(X + ", "+ Y);
        //This converts the X pixels into position
        if (X > 49 && X < 100){
            var GridX = 1;
        }
        if (X > 100 && X < 150){
            var GridX = 2;
        }
        if (X > 149 && X < 200){
            var GridX = 3;
        }
        if (X > 199 && X < 250){
            var GridX = 4;
        }
        if (X > 249 && X < 300){
            var GridX = 5;
        }
        if (X > 299 && X < 350){
            var GridX = 6;
        }
        if (X > 349 && X < 400){
            var GridX = 7;
        }
        if (X > 399 && X < 450){
            var GridX = 8;
        }
        if (X > 449 && X < 500){
            var GridX = 9;
        }
        if (X > 499 && X < 550){
            var GridX = 10;
        }
        //This converts the Y pixels into grid postion
        if (Y > 49 && Y < 100){
            var GridY = "1";
        }
        if (Y > 99 && Y < 150){
            var GridY = "2";
        }
        if (Y > 149 && Y < 200){
            var GridY = "3";
        }
        if (Y > 199 && Y < 250){
            var GridY = "4";
        }
        if (Y > 249 && Y < 300){
            var GridY = "5";
        }
        if (Y > 299 && Y < 350){
            var GridY = "6";
        }
        if (Y > 349 && Y < 400){
            var GridY = "7";
        }
        if (Y > 399 && Y < 450){
            var GridY = "8";
        }
        if (Y > 449 && Y < 500){
            var GridY = "9";
        }
        if (Y > 499 && Y < 550){
            var GridY = "10";
        }
        // console.log("enemyMap " + GridX + ", " + GridY)
    });
    $(".friendlyMap").mousemove(function(event){
        var X = event.pageX - $(this).offset().left;
        var Y = event.pageY - $(this).offset().top;
        // console.log(X + ", "+ Y);
        //This converts the X pixels into position
        if (X > 49 && X < 100){
            var GridX = 1;
        }
        if (X > 100 && X < 150){
            var GridX = 2;
        }
        if (X > 149 && X < 200){
            var GridX = 3;
        }
        if (X > 199 && X < 250){
            var GridX = 4;
        }
        if (X > 249 && X < 300){
            var GridX = 5;
        }
        if (X > 299 && X < 350){
            var GridX = 6;
        }
        if (X > 349 && X < 400){
            var GridX = 7;
        }
        if (X > 399 && X < 450){
            var GridX = 8;
        }
        if (X > 449 && X < 500){
            var GridX = 9;
        }
        if (X > 499 && X < 550){
            var GridX = 10;
        }
        //This converts the Y pixels into grid postion
        if (Y > 49 && Y < 100){
            var GridY = "1";
        }
        if (Y > 99 && Y < 150){
            var GridY = "2";
        }
        if (Y > 149 && Y < 200){
            var GridY = "3";
        }
        if (Y > 199 && Y < 250){
            var GridY = "4";
        }
        if (Y > 249 && Y < 300){
            var GridY = "5";
        }
        if (Y > 299 && Y < 350){
            var GridY = "6";
        }
        if (Y > 349 && Y < 400){
            var GridY = "7";
        }
        if (Y > 399 && Y < 450){
            var GridY = "8";
        }
        if (Y > 449 && Y < 500){
            var GridY = "9";
        }
        if (Y > 499 && Y < 550){
            var GridY = "10";
        }
        // console.log("FriendlyMap " + GridX + ", " + GridY)
    });

    $("#Carrier").dblclick(function(){
        $(this).toggleClass('rotated');
    })

});




// Write your JavaScript code.
