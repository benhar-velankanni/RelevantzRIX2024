import React, { useEffect, useState } from "react";
import axios from "axios";
import "../App.css";

function Weather() {
  const [data, setData] = useState(null);

  useEffect(() => {
    axios
      .get(
        "https://api.open-meteo.com/v1/forecast?latitude=9.5851&longitude=77.9579&current=temperature_2m,is_day,rain,relative_humidity_2m,showers,snowfall,wind_speed_10m,wind_direction_10m&timezone=Asia%2FSingapore"
      )
      .then((response) => {
        setData(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
  }, []);

  if (!data) {
    return <div>Loading...</div>;
  }

  return (
    <div className="App">
      <header className="App-header">
        <h3>Simple Weather</h3>
        <table>
          <tr>
            <td class={"var"}>Current temperature:</td>
            <td class={"varValue"}>{data.current.temperature_2m}°C</td>
          </tr>
          <tr>
            <td class={"var"}>Wind Speed:</td>
            <td class={"varValue"}>{data.current.wind_speed_10m} kmph, 10m above ground.</td>
          </tr>
          <tr>
            <td class={"var"}>Wind Direction:</td>
            <td class={"varValue"}>{data.current.wind_direction_10m} Degrees, 10m above ground.</td>
          </tr>
          <tr>
            <td class={"var"}>Is it day?</td>
            <td class={"varValue"}>{data.current.is_day ? "Yes" : "No"}</td>
          </tr>
          <tr>
            <td class={"var"}>Is it raining?</td>
            <td class={"varValue"}>{data.current.rain ? "Yes" : "No"}</td>
          </tr>
        </table>
      </header>
    </div>
  );
}

export default Weather;
