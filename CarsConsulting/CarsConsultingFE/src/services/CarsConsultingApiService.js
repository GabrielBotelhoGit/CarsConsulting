import axios from 'axios';
const CarsConsultingBaseUrl = "/Api/Car";

let getCylinder = (cylinderNumber) => {
  switch (cylinderNumber){
    case 2:
      return 0;
      break;
    case 3:
      return 1;
      break;
    case 4:
      return 2;
      break;
    case 5:
      return 3;
      break;
    case 6:
      return 4;
      break;
    case 8:
      return 5;
      break;
    case 10:
      return 6;
      break;
    case 12:
      return 7;
      break;
    case 16:
      return 8;
      break;
  }
}

let toDataUrl = (url) => {
  return new Promise((resolve, reject) => {
    var xhr = new XMLHttpRequest();
    xhr.onload = function () {
      var reader = new FileReader();
      reader.onloadend = function () {
        resolve(reader.result.split(",")[1]);
      }
      reader.readAsDataURL(xhr.response);
    };
    xhr.open('GET', url);
    xhr.responseType = 'blob';
    xhr.send();
  })  
}

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
  let imageData;
  toDataUrl(car.image)
    .then((response) => {
      imageData = response;
      let carReady = {
        model: car.model.trim(),
        cylinderNumber: getCylinder(car.cylinders),
        driveType: car.fuel_type.trim(),
        maker: car.make.trim(),
        transmissionType: car.transmission.trim(),
        year: car.year.toString(),
        image: imageData
      };
      
      axios.post(CarsConsultingBaseUrl, carReady)
        .then((response) => {
          resolve(response);
        })
        .catch((err) => {
          reject(false);
          console.log(err);
        });
    })
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