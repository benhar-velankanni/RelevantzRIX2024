export function handleFormSubmit(event: SubmitEvent) {
  event.preventDefault();
  const form = event.currentTarget as HTMLFormElement as HTMLFormElement;
  const formData = new FormData(form);

  if ((event.currentTarget as HTMLFormElement).id === "productForm") {
    console.log(
      "Product Form: \n Name: " +
        formData.get("name") +
        "\n Price: " +
        formData.get("price") +
        "\n In Stock: " +
        formData.get("inStock")
    );
    alert(
      "Product Form submitted successfully: \n Name: " +
        formData.get("name") +
        "\n Price: " +
        formData.get("price") +
        "\n In Stock: " +
        formData.get("inStock")
    );
  } else if ((event.currentTarget as HTMLFormElement).id === "bookForm") {
    console.log(
      "Book Form: \n Title: " +
        formData.get("title") +
        "\n Author: " +
        formData.get("author") +
        "\n Pages: " +
        formData.get("pages") +
        "\n Is Available: " +
        formData.get("isAvailable")
    );
    alert(
      "Book Form submitted successfully: \n Title: " +
        formData.get("title") +
        "\n Author: " +
        formData.get("author") +
        "\n Pages: " +
        formData.get("pages") +
        "\n Is Available: " +
        formData.get("isAvailable")
    );
  } else if ((event.currentTarget as HTMLFormElement).id === "carForm") {
    console.log(
      "Car Form: \n Make: " +
        formData.get("make") +
        "\n Model: " +
        formData.get("model") +
        "\n Year: " +
        formData.get("year") +
        "\n In Stock: " +
        formData.get("inStock")
    );
    alert(
      "Car Form submitted successfully: \n Make: " +
        formData.get("make") +
        "\n Model: " +
        formData.get("model") +
        "\n Year: " +
        formData.get("year") +
        "\n In Stock: " +
        formData.get("inStock")
    );
  } else if ((event.currentTarget as HTMLFormElement).id === "employeeForm") {
    console.log(
      "Employee Form: \n Name: " +
        formData.get("name") +
        "\n Position: " +
        formData.get("position") +
        "\n Salary: " +
        formData.get("salary") +
        "\n Is Full Time: " +
        formData.get("isFullTime")
    );
    alert(
      "Employee Form submitted successfully: \n Name: " +
        formData.get("name") +
        "\n Position: " +
        formData.get("position") +
        "\n Salary: " +
        formData.get("salary") +
        "\n Is Full Time: " +
        formData.get("isFullTime")
    );
  } else if ((event.currentTarget as HTMLFormElement).id === "courseForm") {
    console.log(
      "Course Form: \n Name: " +
        formData.get("name") +
        "\n Description: " +
        formData.get("description") +
        "\n Duration: " +
        formData.get("duration") +
        "\n Is Online: " +
        formData.get("isOnline")
    );
    alert(
      "Course Form submitted successfully: \n Name: " +
        formData.get("name") +
        "\n Description: " +
        formData.get("description") +
        "\n Duration: " +
        formData.get("duration") +
        "\n Is Online: " +
        formData.get("isOnline")
    );
  }

  if ((event.currentTarget as HTMLFormElement) != null) {
    (event.currentTarget as HTMLFormElement).reset();
  }
}
