import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <div>
        <h1>Welcome to PizzaRyja!</h1>
        <p>This is an app created as a homework assignment. Technologies that were used in this app:</p>
        <ul>
          <li><a href='https://get.asp.net/'>ASP.NET Core</a> and <a href='https://msdn.microsoft.com/en-us/library/67ef8sbd.aspx'>C#</a> for cross-platform server-side code</li>
          <li><a href='https://facebook.github.io/react/'>React</a> for client-side code</li>
                <li><a href='http://getbootstrap.com/'>Bootstrap</a> for layout and styling</li>
                <li><a href='https://chat.openai.com/'>ChatGPT</a> because... Because of reasons...</li>
                <li><a href='https://azure.microsoft.com/'>Microsoft Azure</a> for hosting this wonderful application</li>
        </ul>
        <p>Here is what you can do with this app:</p>
        <ul>
          <li><strong>Create an order</strong>. Choose a pizza size and as many toppings as you like</li>
          <li><strong>View existing orders</strong>. You will see all the information about the order including the pizza size, list of toppings and the total price.</li>
        </ul>
        <p>Hope you enjoy this app and maybe get hungry while exploring and maybe order a real pizza through a real app...</p>
      </div>
    );
  }
}
