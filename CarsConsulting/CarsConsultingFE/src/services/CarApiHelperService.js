import axios from 'axios';
const CarApiBaseUrl = "https://api.api-ninjas.com/v1/cars?limit=50";
const CarImageBaseUrl = "https://api.api-ninjas.com/v1/cars?limit=50";
const config = {
  headers: {
    "X-Api-Key": "wshLRZoB4CLPFSWSO+2GXQ==XFlxaRudZLfb7LoV"
  }
};

export const getByBrandAndYear = (brand, Year) => {
  config.params = {
    make: brand,
    year: Year
  };
  return new Promise((resolve, reject) => {
    axios.get(CarApiBaseUrl, config)
      .then((response) => {
        console.log(response);
        resolve(response);
      })
      .catch((err) => {
        console.log(err);
      });
  })
};
