document.addEventListener('DOMContentLoaded', function () {
	const startDateInput = document.getElementById('startDateInput');
	const endDateInput = document.getElementById('endDateInput');

	// Calculate 180 days from today
	const maxDate = new Date();
	maxDate.setDate(maxDate.getDate() + 180);

	// Initialize Flatpickr for Start Date
	const fpStartDate = flatpickr(startDateInput, {
		dateFormat: "Y-m-d", // Format matching C# DateOnly.ToString("yyyy-MM-dd")
		minDate: "today",
		maxDate: maxDate,
		onClose: function (selectedDates, dateStr, instance) {
			if (selectedDates.length > 0) {
				// When start date is selected/changed, update end date's minDate
				fpEndDate.set('minDate', selectedDates[0]);

				// If end date is now before the new start date, clear it or adjust it
				if (fpEndDate.selectedDates.length > 0 && fpEndDate.selectedDates[0] < selectedDates[0]) {
					fpEndDate.clear(); // Clear the end date if it's invalid
					endDateInput.setCustomValidity('Drop-Off Date must be on or after Pick-Up Date.');
				} else {
					endDateInput.setCustomValidity(''); // Clear custom validation message if valid
				}
			}
		}
	});

	// Initialize Flatpickr for End Date
	const fpEndDate = flatpickr(endDateInput, {
		dateFormat: "Y-m-d", // Format matching C# DateOnly.ToString("yyyy-MM-dd")
		minDate: "today", // Initial minDate, will be updated by startDate
		maxDate: maxDate,
		onClose: function (selectedDates, dateStr, instance) {
			if (selectedDates.length > 0 && fpStartDate.selectedDates.length > 0) {
				// Live validation: End Date must be >= Start Date
				if (selectedDates[0] < fpStartDate.selectedDates[0]) {
					endDateInput.setCustomValidity('Drop-Off Date must be on or after Pick-Up Date.');
				} else {
					endDateInput.setCustomValidity(''); // Clear custom validation message if valid
				}
			} else if (selectedDates.length > 0 && fpStartDate.selectedDates.length === 0) {
				// If end date is picked but start date isn't, ensure end date is valid relative to today
				endDateInput.setCustomValidity('');
			}
		}
	});

	// Initial check in case values are pre-filled by the model
	// This ensures the minDate for EndDate is set correctly on page load
	if (startDateInput.value) {
		const initialStartDate = new Date(startDateInput.value);
		fpEndDate.set('minDate', initialStartDate);
	}

	// Add an input event listener to the endDateInput to clear validation messages
	// if the user types something invalid
	endDateInput.addEventListener('input', function () {
		if (endDateInput.value) {
			endDateInput.setCustomValidity('');
		}
	});

});