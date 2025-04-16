// import './style.css'
// import { TextInput, CheckboxInput, processFormInput } from './Formhandler'


// document.getElementById('exampleForm')!.addEventListener('submit', (event) => {
//   event.preventDefault();

//   const textInputElement = document.getElementById('name') as HTMLInputElement;
//   const checkboxInputElement = document.getElementById('confirmation') as HTMLInputElement;

//   const textInput = new TextInput(textInputElement.value);
//   const checkboxInput = new CheckboxInput(checkboxInputElement.checked);

//   processFormInput(textInput);
//   processFormInput(checkboxInput);
// });



export function handleSubmit(event: SubmitEvent) {
  event.preventDefault();
  const form =event.currentTarget as HTMLFormElement;
  const formData = new FormData(form);
  if((event.currentTarget as HTMLFormElement).id === "productform"){
    console.log(
      "Product Form: \n Name: " +
        formData.get("name") +
        "\n Price: " +
        formData.get("price") +
        "\n In Stock: " +
        formData.get("inStock")
    );
  }
  else if((event.currentTarget as HTMLFormElement).id === "bookform"){
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
  }
  else if((event.currentTarget as HTMLFormElement).id === "carform"){
    console.log(
      "Car Form: \n Make: " +
        formData.get("make") +
        "\n Model: " +
        formData.get("model") +
        "\n Year: " +
        formData.get("year") +
        "\n Is Running: " +
        formData.get("isRunning")
    );
  }
  else if((event.currentTarget as HTMLFormElement).id === "courseform"){
    console.log(
      "Course Form: \n Name: " +
        formData.get("name") +
        "\n Price: " +
        formData.get("price") +
        "\n Is Free: " +
        formData.get("isFree")
    );
  }
  else if((event.currentTarget as HTMLFormElement).id === "employeeform"){
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
  }
  if(event.currentTarget != null){
    (event.currentTarget as HTMLFormElement).reset();
  }
}


