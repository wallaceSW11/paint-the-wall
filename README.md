# Paint the wall

Project to calculate how much ink you'll need to paint four walls.

Each 1 liter can paint 5 m².

You need to inform Height (centimeters), Width (centimeters), Doors and Windows for four walls to calculate how much liters.

The app will calculate to use the cans with this liters:
18L
3.6L
2.5L
0.5L

## Getting started

Clone or download this repository to run the app.

Access the "backend" folder and open the Command line (cmd or terminal).

Type:
    dotnet restore

then
    dotnet watch run

(will open the Swagger to test manually the API)


Then, access the "frontend" folder and open the command line and type:

npm install

then

npm serve
or
yarn start


## Technologies

Backend:
  netcore 6
  Swagger

Frontend:
  Vue 3.2.13
  Axios
  scss (saas)


## Unit test

Access the "backend.test" folder, open the command line and type:
dotnet test