import axios from 'axios';
const CarApiBaseUrl = "https://api.api-ninjas.com/v1/cars?limit=50";
const CarImageBaseUrl = "https://cdn-01.imagin.studio/getImage?";
const carApiConfig = {
  headers: {
    "X-Api-Key": "wshLRZoB4CLPFSWSO+2GXQ==XFlxaRudZLfb7LoV"
  }
};

const carImageConfig = {
  params: {
    customer: "ptcarsconsulting"
  }
};

const getCarImage = (brand, year, model) => {
  carImageConfig.params.make = brand;
  carImageConfig.params.modelYear = year;
  carImageConfig.params.modelFamily = model;

  return new Promise((resolve, reject) => {
    axios.get(CarImageBaseUrl, carImageConfig)
      .then((response) => {
        resolve(response);
      })
      .catch((err) => {
        console.log(err);
      });
  })
};

export const getByBrandAndYear = (brand, year) => {
  carApiConfig.params = {
    make: brand,
    year: year
  };

  return new Promise((resolve, reject) => {
    axios.get(CarApiBaseUrl, carApiConfig)
      .then((response) => {
        return getCarImage(brand, year, response.data[0].model)
        resolve(response);
      })
      .then((result) => {
        console.log(result);
      })
      .catch((err) => {
        console.log(err);
      });
  })
};
