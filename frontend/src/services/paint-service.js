import api from "./api";

function calculate(walls) {
    return new Promise((resolve, reject) => {
        return api
            .post("/paint", walls)
            .then((response) => resolve(response))
            .catch((error) => {
                console.log(error);
                reject(error);
            });
    });
}

export default {
    calculate,
};
