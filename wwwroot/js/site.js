function deleteCourse(courseId) {
    if (confirm("Are you sure you want to delete this course?")) {
        $.ajax({
            type: 'POST',
            url: '/Cours/DeleteCourse?courseId=' + courseId,
            contentType: 'application/json; charset=utf-8',
           
            success: function () {
                location.reload();
            },
            error: function () {
                alert('Error deleting the course.');
            }
        });
    }
}
function deleteAdmin(adminId) {
    if (confirm("Are you sure you want to delete this admin?")) {
        $.ajax({
            type: 'POST',
            url: '/Admin/DeleteAdmins?adminId=' + adminId,
            contentType: 'application/json; charset=utf-8',

            success: function () {
                location.reload();
            },
            error: function () {
                alert('Error deleting the admin.');
            }
        });
    }
}
function editCourse(courseId) {
    window.location.href = '/Cours/EditCourse?courseId=' + courseId;
}
