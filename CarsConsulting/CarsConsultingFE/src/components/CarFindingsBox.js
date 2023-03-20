import React from 'react';
import { library } from "@fortawesome/fontawesome-svg-core";
import { faPlus } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { confirmAlert } from 'react-confirm-alert';
import { createCar } from '../services/CarsConsultingApiService';
import 'react-confirm-alert/src/react-confirm-alert.css';

library.add(faPlus);


const CarFindingsBox = ({ car, navigate }) => {
  let onAdd = (car) => {
    confirmAlert({
      title: 'Confirm to add',                        
      message: 'Are you sure you want to save this car?',                            
      buttons: [
        {
          label: 'Cancel'
        }, {
          label: 'Confirm',
          onClick: () => {
            createCar(car)
              .then(() => {
                navigate('/', { replace: true });
              })
          }
        }
      ]
    })
  }

  let getTitleCase = (string) => {
    var sentence = string.toLowerCase().split(" ");
    for (var i = 0; i < sentence.length; i++) {
      sentence[i] = sentence[i][0].toUpperCase() + sentence[i].slice(1) + " ";
    }
    return sentence.toString();
  }

  if (car && !car.adjusted) {
    car.model = getTitleCase(car.model);
    car.transmission = car.transmission == "a" ? "Automatic" : "Manual";
    car.fuel_type = getTitleCase(car.fuel_type);
    car.make = getTitleCase(car.make);
    car.adjusted = true;
  }  

  return (
    <div className="carBox">
      <div className="cardHeader">
        <FontAwesomeIcon icon="fa-solid fa-plus" className="green" onClick={() => onAdd(car)} />
      </div>
      <img src={car.image} alt="loading"/>          
      <div className="infoLine">
        <span>
          Model:
        </span>
        <span>
          {car.model}
        </span>
      </div>
      <div className="infoLine">
        <span>
          Year:
        </span>
        <span>
          {car.year}
        </span>
      </div>
      <div className="infoLine">
        <span>
          Transmission:
        </span>
        <span>
          {car.transmission}
        </span>
      </div>      
      <div className="infoLine">
        <span>
          Fuel:
        </span>
        <span>
          {car.fuel_type}
        </span>
      </div>
      <div className="infoLine">
        <span>
          Brand:
        </span>
        <span>
          {car.make}
        </span>
      </div>
    </div>
  );  
}

export default CarFindingsBox;
