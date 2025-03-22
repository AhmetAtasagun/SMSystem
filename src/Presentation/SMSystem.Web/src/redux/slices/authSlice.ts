import { createSlice, createAsyncThunk, PayloadAction } from '@reduxjs/toolkit';
import axios from 'axios';
import jwtDecode from 'jwt-decode';
import Cookies from 'js-cookie';

interface AuthState {
  token: string | null;
  refreshToken: string | null;
  isAuthenticated: boolean;
  user: any | null;
  loading: boolean;
  error: string | null;
}

const initialState: AuthState = {
  token: null,
  refreshToken: null,
  isAuthenticated: false,
  user: null,
  loading: false,
  error: null,
};

// API base URL
import { API_URL } from '../../app/api/axiosConfig';

export const login = createAsyncThunk(
  'auth/login',
  async (credentials: { email: string; password: string }, { rejectWithValue }) => {
    try {
      const response = await axios.post(`${API_URL}/auth/login`, credentials);
      return response.data;
    } catch (error: any) {
      return rejectWithValue(error.response?.data?.message || 'Login failed');
    }
  }
);

export const refreshTokenThunk = createAsyncThunk(
  'auth/refreshToken',
  async (refreshToken: string, { rejectWithValue }) => {
    try {
      const response = await axios.post(`${API_URL}/auth/refresh-token`, { refreshToken });
      return response.data;
    } catch (error: any) {
      return rejectWithValue(error.response?.data?.message || 'Token refresh failed');
    }
  }
);

const authSlice = createSlice({
  name: 'auth',
  initialState,
  reducers: {
    logout: (state: AuthState) => {
      state.token = null;
      state.refreshToken = null;
      state.isAuthenticated = false;
      state.user = null;
      
      // Remove token from cookies
      Cookies.remove('auth_token');
    },
    clearError: (state: AuthState) => {
      state.error = null;
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(login.pending, (state: AuthState) => {
        state.loading = true;
        state.error = null;
      })
      .addCase(login.fulfilled, (state: AuthState, action: PayloadAction<any>) => {
        state.loading = false;
        state.isAuthenticated = true;
        state.token = action.payload.token;
        state.refreshToken = action.payload.refreshToken;
        
        // Store token in cookies for server-side authentication
        Cookies.set('auth_token', action.payload.token, { expires: 7 });
        
        // Decode the JWT to get user info
        try {
          const decodedToken: any = jwtDecode(action.payload.token);
          state.user = {
            id: decodedToken.nameid,
            email: decodedToken.email,
            name: decodedToken.name
          };
        } catch (error) {
          console.error('Failed to decode token:', error);
        }
      })
      .addCase(login.rejected, (state: AuthState, action: PayloadAction<any>) => {
        state.loading = false;
        state.error = action.payload as string;
      })
      .addCase(refreshTokenThunk.fulfilled, (state: AuthState, action: PayloadAction<any>) => {
        state.token = action.payload.token;
        state.refreshToken = action.payload.refreshToken;
        state.isAuthenticated = true;
        
        // Update token in cookies
        Cookies.set('auth_token', action.payload.token, { expires: 7 });
        
        // Decode the JWT to get user info
        try {
          const decodedToken: any = jwtDecode(action.payload.token);
          state.user = {
            id: decodedToken.nameid,
            email: decodedToken.email,
            name: decodedToken.name
          };
        } catch (error) {
          console.error('Failed to decode token:', error);
        }
      })
      .addCase(refreshTokenThunk.rejected, (state: AuthState) => {
        // If token refresh fails, log the user out
        state.token = null;
        state.refreshToken = null;
        state.isAuthenticated = false;
        state.user = null;
      });
  },
});

export const { logout, clearError } = authSlice.actions;
export default authSlice.reducer;