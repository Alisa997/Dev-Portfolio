// Task 2. Design a class in ES6+ syntax to represent weather data: temperature, pressure,
// humidity, wind speed and direction, graphical representation of atmospheric phenomena (clear,
// cloudy, rain, etc. – no more than 5). Define a method to form a string for displaying data in markup.
// Override the toString() method for simple output to the console. Create an array of weather data for
// the week, display it on the page. By commands from the buttons, display the weather data, sorted
// (only when displaying, the order of elements in the original array should not change): by decreasing
// temperature, by increasing pressure, by decreasing wind speed.
// By commands from the buttons, highlight the windiest and calmest days.
// There should also be a button to display the original array without highlighted elements.

class Weather {
    constructor(number, temperature, pressure, humidity, wind, weatherImg) {
        this.number = number;          // day of the week
        this.temperature = temperature;// temperature
        this.pressure = pressure;      // pressure
        this.humidity = humidity;      // humidity
        this.wind = {
            speed: wind.speed,         // wind speed
            direction: wind.direction, // wind direction
        };
        this.weatherImg = weatherImg;  // graphical representation of atmospheric phenomena
    } // constructor

    // getters and setters
    get temperature() { return this._temperature }
    set temperature(value) { this._temperature = value }

    get pressure() { return this._pressure }
    set pressure(value) { this._pressure = value < 1200 ? value : 1000; }

    get humidity() { return this._humidity }
    set humidity(value){ this._humidity = value > 0 ? value : 68; }

    get weatherImg() { return this._weatherImg }
    set weatherImg(value){ this._weatherImg = value }

    // forming the string for display
    toShow() {
        return `<div class="object-block" id="weather${this.number}"><h3>Day ${this.number}:</h3><p>
            <img src='../img/task2/${this.weatherImg}' height='120'/><br>
            Temperature: ${this.temperature}&#176;C<br>
            Pressure: ${this.pressure} hPa<br>
            Humidity: ${this.humidity}%<br>
            Wind Speed: ${this.wind.speed} km/h<br>
            Wind Direction: ${this.wind.direction}</p></div>`
    } // toShow

    // output object as a string
    toString() {
        return `Day ${this.number}: temperature: ${this.temperature}&#176;C,
            pressure: ${this.pressure} hPa, humidity: ${this.humidity}%,
            wind speed: ${this.wind.speed} km/h, wind direction: ${this.wind.direction}`
    }// toString
} // Weather

// weather data array
let weatherForecast = [
    new Weather(1, getIntRand(20,27),1012,82,{speed:4, direction:"E"}, "sunny.gif"),
    new Weather(2, getIntRand(14,17),getIntRand(1000,1100),getIntRand(40,100),{speed:7, direction:"E"}, "cloudy.gif"),
    new Weather(3, getIntRand(10,12),getIntRand(1000,1160),getIntRand(80,100),{speed:10, direction:"NE"}, "rainy.gif"),
    new Weather(4, getIntRand(8,10),getIntRand(1000,1160),getIntRand(80,100),{speed:10, direction:"N"}, "storm.gif"),
    new Weather(5,getIntRand(10,12),getIntRand(1000,1160),getIntRand(80,100),{speed:10, direction:"E"}, "rainy.gif"),
    new Weather(6,getIntRand(14,17),getIntRand(1000,1100),getIntRand(40,100),{speed:7, direction:"SW"}, "cloudy.gif"),
    new Weather(7,getIntRand(20,27),1012,82,{speed:4, direction:"E"}, "sunny.gif"),
];

// display the array
function showWeathers(){
    let titleElem = document.getElementById("title");
    let divElem = document.getElementById("weathers");
    titleElem.innerText = `Original Array`;

    // forming the string for display
    let str = "";
    weatherForecast.forEach(f => str += f.toShow());

    // output
    divElem.innerHTML = str;
}// showWeathers

// sort the array by decreasing temperature
function sortByTemperatureDesc(){
    let titleElem = document.getElementById("title");
    let divElem = document.getElementById("weathers");
    titleElem.innerText = `Array sorted by decreasing temperature`;

    let temp = weatherForecast.slice(0); // copy of the array
    // sorting
    temp.sort((x, y) => y.temperature - x.temperature);
    // forming the string for display
    let str = "";
    temp.forEach(f => str += f.toShow());

    // output
    divElem.innerHTML = str;
}// sortByTemperatureDesc

// sort the array by increasing pressure
function sortByPressure(){
    let titleElem = document.getElementById("title");
    let divElem = document.getElementById("weathers");
    titleElem.innerText = `Array sorted by increasing pressure`;

    let temp = weatherForecast.slice(0); // copy of the array
    // sorting
    temp.sort((x, y) => x.pressure - y.pressure);
    // forming the string for display
    let str = "";
    temp.forEach(f => str += f.toShow());

    // output
    divElem.innerHTML = str;
}// sortByPressure

// sort the array by decreasing wind speed
function sortWindSpeedDesc(){
    let titleElem = document.getElementById("title");
    let divElem = document.getElementById("weathers");
    titleElem.innerText = `Array sorted by decreasing wind speed`;

    let temp = weatherForecast.slice(0); // copy of the array
    // sorting
    temp.sort((x, y) => y.wind.speed - x.wind.speed);
    // forming the string for display
    let str = "";
    temp.forEach(f => str += f.toShow());

    // output
    divElem.innerHTML = str;
}// sortWindSpeedDesc

// highlight the windiest days
function showWindiest(){
    let maxWindSpeed = Math.max(...weatherForecast.map(x => x.wind.speed));
    let temp = weatherForecast.filter(x => x.wind.speed === maxWindSpeed);
    temp.forEach(x=>{
        let weatherElem = document.getElementById(`weather${x.number}`);
        weatherElem.style.borderBottom = weatherElem.style.borderTop ="3px solid dodgerblue";
    });
} // showWindiest

// highlight the calmest days
function showQuietest(){
    let minWindSpeed = Math.min(...weatherForecast.map(x => x.wind.speed));
    let temp = weatherForecast.filter(x => x.wind.speed === minWindSpeed);
    temp.forEach(x=>{
        let weather = document.getElementById(`weather${x.number}`);
        weather.style.borderBottom = weather.style.borderTop = "3px solid red";
    });
} // showQuietest


(function (){
    document.write(`<hr><h2 id="title">Original Array</h2><div class="for-blocks" id="weathers"></div><hr>`);
    showWeathers();
    // buttons
    document.write('<input type="button" onClick="showWeathers()" value="Original Array"/>');
    document.write('<input type="button" onClick="sortByTemperatureDesc()" value="Sort by decreasing temperature"/>');
    document.write('<input type="button" onClick="sortByPressure()" value="Sort by increasing pressure"/>');
    document.write('<input type="button" onClick="sortWindSpeedDesc()" value="Sort by decreasing wind speed"/>');
    document.write('<input type="button" onClick="showWindiest()" value="Windiest days"/>');
    document.write('<input type="button" onClick="showQuietest()" value="Calmest days"/>');
})();
