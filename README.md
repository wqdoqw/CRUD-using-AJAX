# CRUD-using-AJAX
This was done for a part of school assignment.
Used AJAX (JQuery), C#, Visual Studio, HTML

# Key codes

Add
```rb
   $.ajax({
                    type: 'POST',
                    url: uri,
                    data: $('form').serialize(),
                    success: function (data) {
                        displayData();

                    }
                })
```

Find
```rb
    $.ajax({
                    type: 'GET',
                    url: uri + '/' + id,
                    success: function (data) {
                        $('#Player').text(formatItem(data));
                    }

                })
```

Delete
```rb
  $.ajax({
                type: 'DELETE',
                url: uri + '/' + id,
                success: function (data) {
                    displayData();
                },
                error: function (jqXHR, textStatus, err) {
                    $('#movie').text('Error: ' + err);
                }
            })
 ```
 
 Update
 ```rb
  $.ajax({
                    type: 'PUT',
                    url: uri + "/" + id,
                    data: $('form').serialize(),
                    success: function (data) {
                        displayData();
                    }
                })
            }
```
          
![alt text](https://github.com/wqdoqw/CRUD-using-AJAX/blob/master/1.PNG)
