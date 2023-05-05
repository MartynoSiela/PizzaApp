import React, { Component } from "react";

export class OrderCreation extends Component {
  constructor(props) {
    super(props);
    this.state = {
      sizes: [],
      toppings: [],
      selectedSize: "",
      selectedToppings: [],
      price: 0.0,
      notificationMessage: "",
      notificationVisible: false,
      notificationType: "success",
    };
  }

  fetchData = async () => {
    try {
      const sizesResponse = await fetch("api/pizzasize");
      const sizesData = await sizesResponse.json();
      const toppingsResponse = await fetch("api/topping");
      const toppingsData = await toppingsResponse.json();

      this.setState({ sizes: sizesData, toppings: toppingsData });
    } catch (error) {
      console.error("Error fetching data:", error);
    }
  };

  calculatePrice = async () => {
    try {
      const response = await fetch("/api/order/calculate", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          PizzaSizeId: this.state.selectedSize,
          OrderToppings: this.state.selectedToppings,
        }),
      });

      if (response.ok) {
        const price = await response.json();
        this.setState({ price });
      } else {
        this.setState({
          notificationMessage: "Error calculating price",
          notificationVisible: true,
          notificationType: "danger",
        });
        setTimeout(() => {
          this.setState({
            notificationMessage: "",
            notificationVisible: false,
          });
        }, 3000);
      }
    } catch (error) {
      console.error("Error calculating price:", error);
    }
  };

  handleSizeChange = (event) => {
    this.setState({ selectedSize: event.target.value });
  };

  handleToppingsChange = (event) => {
    const { options } = event.target;
    const selectedToppings = Array.from(options)
      .filter((option) => option.selected)
      .map((option) => option.value);

    this.setState({ selectedToppings });
  };

  createOrder = async () => {
    try {
      const response = await fetch("api/order/create", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          PizzaSizeId: this.state.selectedSize,
          OrderToppings: this.state.selectedToppings,
        }),
      });

      if (response.ok) {
        this.setState({
          notificationMessage: "Order created successfully!",
          notificationVisible: true,
          notificationType: "success",
        });
      } else {
        this.setState({
          notificationMessage: "Error creating order",
          notificationVisible: true,
          notificationType: "danger",
        });
      }

      setTimeout(() => {
        this.setState({
          notificationMessage: "",
          notificationVisible: false,
        });
      }, 3000);
    } catch (error) {
      console.error("Error creating order:", error);
    }
  };

  componentDidMount() {
    this.fetchData();
  }

  render() {
    const { sizes, toppings, price, notificationMessage, notificationVisible } =
      this.state;
    return (
      <div className="container">
        <h2>Create Your Pizza Order</h2>
        <div className="row">
          <div className="col-md-6">
            <div className="form-group">
              <label htmlFor="size">Size:</label>
              <select
                id="size"
                className="form-control"
                onChange={this.handleSizeChange}
              >
                <option value="">Select a size</option>
                {sizes.map((size) => (
                  <option key={size.id} value={size.id}>
                    {size.name}
                  </option>
                ))}
              </select>
            </div>
            <div className="form-group">
              <label htmlFor="toppings">Toppings:</label>
              <select
                id="toppings"
                className="form-control"
                multiple
                onChange={this.handleToppingsChange}
              >
                {toppings.map((topping) => (
                  <option key={topping.id} value={topping.id}>
                    {topping.name}
                  </option>
                ))}
              </select>
            </div>
          </div>
          <div className="col-md-6">
            <button
              className="btn btn-primary mb-3"
              onClick={this.calculatePrice}
            >
              Calculate Price
            </button>
            {price !== null && (
              <p>
                Estimated Price: <strong>{price}</strong>
              </p>
            )}
            <button className="btn btn-success" onClick={this.createOrder}>
              Create Order
            </button>
            {notificationVisible && (
              <div
                className={`alert alert-dismissible fade show alert-${this.state.notificationType}`}
                role="alert"
              >
                {notificationMessage}
              </div>
            )}
          </div>
        </div>
      </div>
    );
  }
}
