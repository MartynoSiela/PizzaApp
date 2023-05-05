import React, { Component } from "react";

export class OrdersList extends Component {
  constructor(props) {
    super(props);
    this.state = {
      orders: [],
      loading: true,
    };
  }

  fetchOrders = async () => {
    try {
      const response = await fetch("api/order");
      const ordersData = await response.json();
      this.setState({ orders: ordersData.$values, loading: false });
    } catch (error) {
      console.error("Error fetching orders:", error);
      this.setState({ loading: false });
    }
  };

  componentDidMount() {
    this.fetchOrders();
  }

  render() {
    const { orders, loading } = this.state;
    if (loading) {
      return <div>Loading...</div>;
    }
    return (
      <div className="container">
        <h2>Orders List</h2>
        <table className="table table-striped">
          <thead>
            <tr>
              <th>Order ID</th>
              <th>Pizza Size</th>
              <th>Toppings</th>
              <th>Total Price</th>
            </tr>
          </thead>
          <tbody>
            {Array.isArray(orders) ? (
              orders.map((order) => (
                <tr key={order.id}>
                  <td>{order.id}</td>
                  <td>{order.pizzaSizeName}</td>
                  <td>
                    {order.toppings.$values
                      .map((topping) => topping)
                      .join(", ")}
                  </td>
                  <td>{order.totalPrice.toFixed(2)}</td>
                </tr>
              ))
            ) : (
              <tr>
                <td colSpan="4">No orders found.</td>
              </tr>
            )}
          </tbody>
        </table>
      </div>
    );
  }
}
