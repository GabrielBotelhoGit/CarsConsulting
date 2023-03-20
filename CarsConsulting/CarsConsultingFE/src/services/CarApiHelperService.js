import axios from 'axios';

const CarApiBaseUrl = "https://api.api-ninjas.com/v1/cars?limit=50";
const CarImageBaseUrl = "https://cdn-01.imagin.studio/getImage?customer=ptcarsconsulting";
const carApiConfig = {
  headers: {
    "X-Api-Key": "wshLRZoB4CLPFSWSO+2GXQ==XFlxaRudZLfb7LoV"
  }
};

const getCarImageUrl = (brand, year, model) => {
  return encodeURI(CarImageBaseUrl + `&make=${brand}&modelYear=${year}&modelFamily=${model}`);
};

export const getByBrandAndYear = (brand, year) => {
  carApiConfig.params = {
    make: brand,
    year: year
  };

  return new Promise((resolve, reject) => {
    axios.get(CarApiBaseUrl, carApiConfig)
      .then((response) => {
        for (let i = 0; i < response.data.length; i++){
          response.data[i].id = i;
          response.data[i].image = getCarImageUrl(brand, year, response.data[i].model.split(" ")[0]);
          response.data[i].adjusted = false;
        }       
        resolve(response);
      })
      .catch((err) => {
        console.log(err);
      });
  })
};
