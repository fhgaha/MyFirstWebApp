$(function() {
    console.log("Page is ready");

    //edit-product-button class is in _productCard.cshtml
    $(document).on("click", ".edit-product-button", function () {
        console.log("You clicked button " + $(this).val());

        var productID = $(this).val();

        $.ajax({
            type: "json",
            data: {
                "id": productID //id is what method ShowOneProductJSON expects
            },
            url: "/products/ShowOneProductJSON",  //this tell go to ShowOneProductJSON. Although method 
            //returns not a view but Json, the url path should point at place where that view would be placed
            //or you can interpretate it as name of 'controller/method'
            success: function (data) {  //data - what method from 'url' with parameter 'data' will return
                console.log(data);

                //fill in the form
                $("#modal-input-id").val(data.id);
                $("#modal-input-name").val(data.name);
                $("#modal-input-price").val(data.price);
                $("#modal-input-description").val(data.description);
            }
        });
    });

    $("#save-button").click(function () {

        //get values from the input field and create a json object to submit to the controller to be saved
        var Product = {
            "Id": $("#modal-input-id").val().trim(),
            "Name": $("#modal-input-name").val().trim(),
            "Price": $("#modal-input-price").val().trim(),
            "Description": $("#modal-input-description").val().trim()
        }

        console.log(Product);

        //save the updated product record in database using the controller
        $.ajax({
            type: "json",
            data: Product,
            url: "/products/ProcessEditReturnPartial",
            success: function (data) {
                console.log(data);
                $("#card-number-" + Product.Id).html(data).hide().fadeIn(1600);
            }
        })
    })
});