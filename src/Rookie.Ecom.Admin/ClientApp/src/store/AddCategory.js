import { timers } from "jquery";
import axios from "axios";

const addCategoryType = 'ADD_CATEGORY';
const finishAddCaregoryType = 'FINISH_ADD_CATEGORY'
const initialState = { isAdding: false };

const apiCategoty = 'https://localhost:5011/api/Category';

//https://stackoverflow.com/questions/105034/how-to-create-a-guid-uuid#answer-2117523
function createGUID() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    });
}

export const actionCreators = {
    addCategory: (name, desc, imageUrl) => async (dispatch, getState) => {
        dispatch({ type: addCategoryType });
        await axios.post(apiCategoty, {
            "id": createGUID(),
            "createdDate": new Date().toISOString,
            "updatedDate": new Date().toISOString,
            "creatorId": createGUID(),
            "pubished": true,
            "name": name,
            "desc": desc,
        });
        alert("Add new category success !")
        dispatch({ type: finishAddCaregoryType })
    }
};

export const reducer = (state, action) => {
  state = state || initialState;

    if (action.type === addCategoryType) {
        return {
            ...state,
            isAdding: true
        };
    }

    if (action.type === finishAddCaregoryType) {
        return {
            ...state,
            isAdding: false
        };
    }

  return state;
};
