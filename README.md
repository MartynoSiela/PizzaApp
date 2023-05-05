# PizzaRyja
## Description
This is an app created as a homework assignment. Technologies that were used in this app:

- [ASP.NET Core](https://dotnet.microsoft.com/en-us/apps/aspnet) and [C#](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/?redirectedfrom=MSDN) for cross-platform server-side code
- [React](https://react.dev/) for client-side code
- [Bootstrap](https://getbootstrap.com/) for layout and styling
- [ChatGPT](https://chat.openai.com/) because... Because of reasons...
- [Microsoft Azure](https://azure.microsoft.com/en-us/) for hosting this wonderful application

The site should be accessible [here](https://pizzaapp20230505182407.azurewebsites.net/) or it should be possible to build and run the app locally using the code in this repository
## Issues
Given more time (and probably know how) I would solve these issues:
- The price calculation code currently is duplicated in two locations, it would be great to extract that code to a single method
- Order list returned from the api for some reason is a nested object which has weird $ids and $values scattered inside that should not be there.
- OrderCreation React component has a lot of various functions and probably it would be nice to extract them elsewhere
- Make the app pretier
- Add a way to clear the order list as to do it now I would need to redeploy the app
- Clean the unnecessary files that were created by the project template
- Probably more issues are present that I haven't thought about
- OrderDto model is completely unnecessary as it was created in order to solve the nested object issue (which it did not) and i ended up just updating the react component to display data correctly and did not refactor the backend code. It is already 1:17 and i want to sleep.
## Task
Below you can find the full description that was provided for this task
### Task Description
Create a web application to calculate a pizza order’s total cost and review submitted orders.
### Functional requirements
- The application should allow users to select the size and toppings for their pizza order.
- The application should calculate the total cost of the order based on the size and toppings selected.
- The application should display the total cost of the order to the user.
- User should be able to save orders and view all saved orders in a list.
- Oder list should be on a separate page.

Calculation rules:
- The cost of the pizza should be based on the size selected. Small pizzas cost €8, medium pizzas cost
€10, and large pizzas cost €12.
- The cost of each topping should be added to the base cost of the pizza. The toppings cost $1 each.
- If the user selects more than 3 toppings, a discount of 10% should be applied to the total cost.
### Technical requirements
- The back end should be built using ASP.NET Core and should use an EF Core in-memory database to
store pizza size and topping data.
- The front end should be built using React and can use a modern UI library such as Bootstrap or
Material UI.
- All calculation logic must be implemented in the back end.
### Nice to have (optional)
- Unit tests in the backend.
- Web app deployed and accessible via a public URL.
### Evaluation criteria
- Functionality of the web app (could be not 100% finished).
- Clean code.
- Decisions on architecture for both the back end and front end.
- Tools used to build this app.
- Design patterns.
