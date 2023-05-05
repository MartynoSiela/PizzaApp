import { Home } from "./components/Home";
import { OrderCreation } from "./components/OrderCreation";
import { OrdersList } from "./components/OrdersList";

const AppRoutes = [
  {
    index: true,
    element: <Home />,
  },
  {
    path: "/orders/create",
    element: <OrderCreation />,
    },
    {
        path: "/orders",
        element: <OrdersList />,
    },
];

export default AppRoutes;
