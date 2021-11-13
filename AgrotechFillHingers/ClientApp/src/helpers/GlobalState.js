import { createGlobalState } from 'react-hooks-global-state';

const initialState = {
    id: '',
    role: 3,
    photo: ''
};
const { setGlobalState, useGlobalState } = createGlobalState(initialState);

export const setUserId = (value) => {
    setGlobalState('id', value);
}

export const setUserRoles = (value) => {
    setGlobalState('role', value);
}

export const setUserPhoto = (value) => {
    setGlobalState('photo', value);
}

export { useGlobalState }