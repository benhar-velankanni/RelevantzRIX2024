var Course = /** @class */ (function () {
    function Course(title, instructor, duration, isOnline) {
        this.title = title;
        this.instructor = instructor;
        this.duration = duration;
        this.isOnline = isOnline;
    }
    return Course;
}());
var CheckBoxClassInput = /** @class */ (function () {
    function CheckBoxClassInput(checked) {
        this.checked = checked;
    }
    CheckBoxClassInput.prototype.getValue = function () {
        return this.checked;
    };
    return CheckBoxClassInput;
}());
var form = document.getElementById("course-form");
form.addEventListener('submit', function (e) {
    e.preventDefault();
    var title = document.getElementById('title');
    var instructor = document.getElementById('instructor');
    var duration = document.getElementById('duration');
    var online = document.getElementById('online');
    var checkInput = new CheckBoxClassInput(online.checked);
    var course = new Course(title.value, instructor.value, Number(duration.value), Boolean(checkInput.getValue()));
    console.log("--- Course Details ---");
    console.log("Title : ".concat(course.title));
    console.log("Instructor : ".concat(course.instructor));
    console.log("Duration : ".concat(course.duration));
    if (course.isOnline == true) {
        console.log("Is Online : Yes");
    }
    else {
        console.log("Is Online : No");
    }
});
