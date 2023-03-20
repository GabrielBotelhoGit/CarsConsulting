import axios from 'axios';
const CarsConsultingBaseUrl = "/Api/Car";

export const getAllCars = () => {
  return new Promise((resolve, reject) => {
    axios.get(CarsConsultingBaseUrl)
      .then((response) => {
        resolve(response);
      })
      .catch((err) => {
        reject(false);
        console.log(err);
      });
  })
};

export const getCarById = (id) => {  
  return new Promise((resolve, reject) => {
    axios.get(CarsConsultingBaseUrl + "/" + id)
      .then((response) => {
        resolve(response);
      })
      .catch((err) => {
        reject(false);
        console.log(err);
      });
  })
};

export const createCar = (car) => {
  return new Promise((resolve, reject) => {
    axios.post(CarsConsultingBaseUrl, car)
      .then((response) => {
        resolve(response);
      })
      .catch((err) => {
        reject(false);
        console.log(err);
      });
  })
};

export const updateCar = (car) => {
  return new Promise((resolve, reject) => {
    axios.post(CarsConsultingBaseUrl + "/" + car.id, car)
      .then((response) => {
        resolve(response);
      })
      .catch((err) => {
        reject(false);
        console.log(err);
      });
  })
};

export const deleteCar = (id) => {
  return new Promise((resolve, reject) => {
    axios.delete(CarsConsultingBaseUrl + "/" + id)
      .then((response) => {
        resolve(response);
      })
      .catch((err) => {
        reject(false);
        console.log(err);
      });
  })
};

export const getCarEnums = () => {
  return new Promise((resolve, reject) => {
    axios.get(CarsConsultingBaseUrl + "/Enums")
      .then((response) => {
        resolve(response);
      })
      .catch((err) => {
        reject(false);
        console.log(err);
      });
  })
};