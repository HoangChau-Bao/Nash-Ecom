import { timers } from "jquery";
import axios from "axios";
import { redirectSuccess } from "redux-oidc";
import { Redirect } from "react-router-dom";

const updateCategoryType = 'UPDATE_CATEGORY';
const finishUpdateCaregoryType = 'FINISH_UPDATE_CATEGORY'
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
    updateCategory: (id, name, desc) => async (dispatch, getState) => {
        dispatch({ type: updateCategoryType });
        await axios.put(apiCategoty, {
            "id": id,
            "updatedDate": new Date().toISOString,
            "name": name,
            "desc": desc,
        });
        alert("Category updated !");
        dispatch({ type: finishUpdateCaregoryType })
    }
};

export const reducer = (state, action) => {
  state = state || initialState;

    if (action.type === updateCategoryType) {
        return {
            ...state,
            isAdding: true
        };
    }

    if (action.type === finishUpdateCaregoryType) {
        return {
            ...state,
            isAdding: false
        };
    }

  return state;
};
