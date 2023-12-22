function deleteCourse(courseId) {
    if (confirm("Are you sure you want to delete this course?")) {
        window.location.href = '/Cours/DeleteCourses?courseId=' + courseId;
        $.ajax({
            type: 'POST',
            url: '/Cours/DeleteCourses?courseId=' + courseId,
            contentType: 'application/json; charset=utf-8',
           
            success: function () {
                location.reload();
            },
            error: function () {
                alert('Error deleting the course.');
            }
        });
    }