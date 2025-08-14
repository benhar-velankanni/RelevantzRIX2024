import React from "react";

class Employee extends React.Component {
    render() {
        return (
            <div>
                <h4>Relevatz Employee Details:</h4>
                <table>
                    <tr>
                        <td class={"var"}>Full Name: </td>
                        <td class={"varValue"}>{this.props.Name}</td>
                    </tr>
                    <tr>
                        <td class={"var"}>Designation: </td>
                        <td class={"varValue"}>{this.props.Designation}</td>
                    </tr>
                    <tr>
                        <td class={"var"}>Age: </td>
                        <td class={"varValue"}>{this.props.Age}</td>
                    </tr>
                    <tr>
                        <td class={"var"}>Deparment: </td>
                        <td class={"varValue"}>{this.props.Department}</td>
                    </tr>
                </table>
            </div>
        );
    }
}

export default Employee;