import React, { useEffect } from 'react';
import '../App.css'

function HomePage() {

    useEffect(() => {

        document.title = "Translator-Inator";

    }, []);

  return (
      <div className="container">
          <h1>Welcome to Translator-Inator!</h1>
          <h4>An obvious "Phineas and Ferb" Reference!</h4>

          <br />

          <p>Lorem ipsum dolor sit amet consectetur adipiscing elit. Quisque faucibus ex sapien vitae pellentesque sem placerat. In id cursus mi pretium tellus duis convallis. Tempus leo eu aenean sed diam urna tempor. Pulvinar vivamus fringilla lacus nec metus bibendum egestas. Iaculis massa nisl malesuada lacinia integer nunc posuere. Ut hendrerit semper vel class aptent taciti sociosqu. Ad litora torquent per conubia nostra inceptos himenaeos.</p>
      </div>
  );
}

export default HomePage;
