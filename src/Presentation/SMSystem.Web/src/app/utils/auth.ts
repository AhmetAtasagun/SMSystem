import { store } from '../../redux/store';

/**
 * Check if the user is authenticated
 * @returns boolean
 */
export const isAuthenticated = (): boolean => {
  const state = store.getState();
  return state.auth.isAuthenticated && !!state.auth.token;
};

/**
 * Get the current user
 * @returns user object or null
 */
export const getCurrentUser = () => {
  const state = store.getState();
  return state.auth.user;
};

/**
 * Get the authentication token
 * @returns token string or null
 */
export const getToken = (): string | null => {
  const state = store.getState();
  return state.auth.token;
};