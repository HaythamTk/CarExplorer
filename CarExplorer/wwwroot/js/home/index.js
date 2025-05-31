$(function () {
    $('#MakeSelect, #VehicleTypeSelect').select2({
        width: '100%',
        allowClear: true,
        placeholder: function () {
            return $(this).attr('id') === 'MakeSelect' ? '-- Select Make --' : '-- Vehicle Type --';
        }
    });

    $('#MakeSelect').change(function () {
        const makeId = $(this).val();

        $('#VehicleTypeSelect').empty().append('<option value="">-- Vehicle Type --</option>');
        $('#ModelsList').empty();

        if (makeId) {
            $.get('/Home/GetVehicleTypes', { makeId }, function (data) {
                $.each(data, function (i, item) {
                    $('#VehicleTypeSelect').append(new Option(item.text, item.value));
                });

                $('#VehicleTypeSelect').trigger('change.select2');
            });
        }
    });

    $('#MakeSelect, #YearInput, #VehicleTypeSelect').on('change keyup', function () {
        const makeId = $('#MakeSelect').val();
        const year = $('#YearInput').val();
        const vehicleType = $('#VehicleTypeSelect').val();

        $('#ModelsList').empty();

        if (makeId && year && vehicleType) {
            $.get('/Home/GetModels', {
                makeId,
                year,
                vehicleType
            }, function (data) {
                $('#ModelsList').html(data);
            }).fail(function () {
                alert('Something went wrong while fetching models.');
            });
        }
    });
});
