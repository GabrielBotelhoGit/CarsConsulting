import React from 'react';
import { library } from "@fortawesome/fontawesome-svg-core";
import { faCar, faXmark } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { confirmAlert } from 'react-confirm-alert';
import { deleteCar } from '../services/CarsConsultingApiService';
import 'react-confirm-alert/src/react-confirm-alert.css';

library.add(faCar, faXmark);

const CarBox = ({ car, reloadCars }) => {
  let onDelete = (id) => {
    confirmAlert({
      title: 'Confirm to delete',                        
      message: 'Are you sure you want to do this?',                            
      buttons: [
        {
          label: 'Cancel'
        },{
          label: 'Confirm',
          onClick: () => deleteCardBox(id)
        }
      ]
    })
  }

  let deleteCardBox = (id) => {
    deleteCar(id)
      .then(() => {
        reloadCars();
      });
  }

  return (
    <div className="carBox">
      <div className="cardHeader">
        <FontAwesomeIcon icon="fa-solid fa-xmark" onClick={() => onDelete(car.id)} />
      </div>
      {
        car.image ?
          <img src={"data:image/png;base64, " + car.image} alt="Red dot" />
          :
          <FontAwesomeIcon icon="fa-solid fa-car" />
      }
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
          {car.transmissionType}
        </span>
      </div>
      <div className="infoLine">
        <span>
          Number of cylinders:
        </span>
        <span>
          {car.cylinderNumber}
        </span>
      </div>
      <div className="infoLine">
        <span>
          Fuel:
        </span>
        <span>
          {car.driveType}
        </span>
      </div>
      <div className="infoLine">
        <span>
          Brand:
        </span>
        <span>
          {car.maker}
        </span>
      </div>
    </div>
  );  
}

export default CarBox;
