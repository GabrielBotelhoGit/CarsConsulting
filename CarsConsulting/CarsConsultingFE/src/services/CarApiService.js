import axios from 'axios';
const CarApiBaseUrl = "https://api.api-ninjas.com/v1/cars?limit=18";
const config = {
  headers: {
    "X-Api-Key": "wshLRZoB4CLPFSWSO+2GXQ==XFlxaRudZLfb7LoV"
  }
};

export const getByBrand = (brand) => {
  return new Promise((resolve, reject) => {
    axios.get(CarApiBaseUrl + "&make=" + brand, config)
      .then((response) => {
        resolve(response);
      })
      .catch((err) => {
        console.log(err);
      });
  })
};
