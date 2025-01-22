// generates a random floating-point number
function getRand(lo, hi) {
    return (lo + (hi - lo) * Math.random()).toFixed(2);
} // getRand

// generates a random integer
function getIntRand(lo, to) {
    return Math.trunc(getRand(lo, to));
} // getIntRand
