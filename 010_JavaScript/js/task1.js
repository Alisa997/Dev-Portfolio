// Task 1. Develop a class hierarchy using ES6+ syntax for representing 3D bodies - sphere, cone, cylinder, cube.
// Develop methods for calculating surface area, volume of the figure, displaying data about the figure
// and comparing the 3D bodies by volume. Develop getters and setters with validation for the assigned values.
// Invalid data should be replaced with default values, error messages are not needed, and exceptions should not be used.
// Also, display images of the 3D shapes.
// Form an array of objects of these classes - two objects of each type. By commands, assigned to buttons,
// sort the copied array by decreasing volumes, by increasing surface areas,
// and display the original array of 3D bodies.

// Sphere (base class)
class Sphere {
    constructor(radius, img = "sphere.png") {
        this.radius = radius;     // radius of the sphere
        this.img = img;           // graphical representation of the shape
    } // constructor

    // getters and setters
    get radius() {return this._radius}
    set radius(value) {this._radius = value > 0? value:1}

    get img() {return this._img}
    set img(value) {this._img = value;}

    // method to calculate the volume of the sphere
    volume() { return 4  * Math.PI * this.radius ** 3 / 3; };

    // method to calculate the surface area of the sphere
    area() { return 4 * Math.PI * this.radius * this.radius; };

    // method to compare figures by volume
    compareTo(obj) {
        return this.volume() - obj.volume();
    } // compareTo

    partialToShow(){
        return` Surface Area: ${this.area().toFixed(2)} m<sup><small>2</small></sup><br>
                Volume: ${this.volume().toFixed(2)} m<sup><small>3</small></sup><br>`;
    } //

    // generate the string to display
    toShow() {
        return`<div class="object-block"><h3>Sphere</h3>
                <img src='../img/task1/${this.img}' height='120'/><br><p><br>
                Radius: ${this.radius} m<br>
                ${this.partialToShow()}
                </p></div>`;
    }; // toShow
} // Sphere

// Cube (derived class)
class Cube extends Sphere{
    constructor(side, img = "cube.png") {
        super(side, img);
    } // constructor

    // getters and setters
    get side() {return this.radius}
    set side(value) {this.radius = value > 0? value:1}

    // method to calculate the volume of the cube
    volume() { return this.side ** 3; };

    // method to calculate the surface area of the cube
    area() { return 6 * this.side ** 2; };

    // generate the string to display
    toShow() {
        return`<div class="object-block"><h3>Cube</h3>
                <img src='../img/task1/${this.img}' height='120'/><br><p><br>
                Side: ${this.side} m<br>
                ${this.partialToShow()}
                </p></div>`;
    }; // toString
} // Cube

// Cone (derived class)
class Cone extends Sphere{
    constructor(radius, height, img = "cone.png") {
        super(radius, img);
        // fields of the derived class
        this.height = height; // height of the cone
        this.l = Math.sqrt(this.radius * this.radius + this.height * this.height); // slant height of the cone
    } // constructor

    // getter and setter
    get height() {return this._height}
    set height(value) {this._height = value > 0? value:1}

    // method to calculate the volume of the cone
    volume() { return this.height / 3 * Math.PI * this.radius * this.radius; };

    // method to calculate the surface area of the cone
    area() { return Math.PI * this.radius * this.l + Math.PI * this.radius *this.radius; };

    // generate the string to display
    toShow() {
        return`<div class="object-block"><h3>Cone</h3>
                <img src='../img/task1/${this.img}' height='120'/><br><p>
                Height: ${this.height} m<br>
                Radius: ${this.radius} m<br>
                ${this.partialToShow()}
                </p></div>`;
    }; // toString
} // Cone

// Cylinder (derived class)
class Cylinder extends Sphere{
    // access to the base class fields
    constructor(radius, height, img = "cylinder.png") {
        super(radius, img);
        // fields of the derived class
        this.height = height; // height of the cylinder
    } // constructor

    // getter and setter
    get height() {return this._height}
    set height(value) {this._height = value > 0? value:1}

    // method to calculate the volume of the cylinder
    volume() { return Math.PI * this.radius * this.radius * this.height; };

    // method to calculate the surface area of the cylinder
    area() { return 2 * Math.PI * this.radius * this.radius + 2 * Math.PI * this.radius * this.height; };


    // generate the string to display
    toShow() {
        return`<div class="object-block"><h3>Cylinder</h3>
                <img src='../img/task1/${this.img}' height='120'/><br><p>
                Height: ${this.height} m<br>
                Radius: ${this.radius} m<br>
                ${this.partialToShow()}
                </p></div>`;
    }; // toString
} // Cylinder

const lo = 0.1, hi = 5;
// array of figures
let figures = [
    new Sphere(getRand(lo, hi)),
    new Sphere(getRand(lo, hi)),
    new Cube(getRand(lo, hi)),
    new Cube(getRand(lo, hi)),
    new Cone(getRand(lo, hi), getRand(lo, hi)),
    new Cone(getRand(lo, hi), getRand(lo, hi)),
    new Cylinder(getRand(lo, hi), getRand(lo, hi)),
    new Cylinder(getRand(lo, hi), getRand(lo, hi)),
];

// display the array of figures
function show(){
    let titleElem = document.getElementById("title");
    let divElem = document.getElementById("figures");
    titleElem.innerText = `Figures in original order`;

    // generate the string to display
    let str = "";
    figures.forEach(f => str += f.toShow());

    // output
    divElem.innerHTML = str;
} // show

// sort the array of figures by decreasing volume
function sortByVolumeDesc(){
    let titleElem = document.getElementById("title");
    let divElem = document.getElementById("figures");
    titleElem.innerText = "Figures by decreasing volumes";

    let temp = figures.slice(0); // copy of the array
    // sorting
    temp.sort((x, y) => y.volume() - x.volume());

    // generate the string to display
    let str = "";
    temp.forEach(f => str += f.toShow());

    // output
    divElem.innerHTML = str;
} // sortByVolumeDesc

// sort the array of figures by increasing surface areas
function sortByArea(){
    let titleElem = document.getElementById("title");
    let divElem = document.getElementById("figures");
    titleElem.innerText = "Figures by increasing areas";

    let temp = figures.slice(0); // copy of the array
    // sorting
    temp.sort((x, y) => x.area() - y.area());

    // generate the string to display
    let str = "";
    temp.forEach(f => str += f.toShow());

    // output
    divElem.innerHTML = str;
} // sortByArea

(function (){
    // output
    document.write('<hr><h2 id="title"></h2><div class="for-blocks" id="figures"></div><hr>');
    show();
    document.write('<input type="button" onClick="show()" value="Original order"/>');
    document.write('<input type="button" onClick="sortByVolumeDesc()" value="Sort by decreasing volume"/>');
    document.write('<input type="button" onClick="sortByArea()" value="Sort by increasing area"/>');
})();
