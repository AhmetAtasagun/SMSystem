import { createSlice, createAsyncThunk, PayloadAction } from '@reduxjs/toolkit';
import axios from 'axios';
import { RootState } from '../store';

interface Sale {
  id: number;
  productId: number;
  productName: string;
  quantity: number;
  price: number;
  totalPrice: number;
  saleDate: string;
  customerName: string;
}

interface SaleState {
  sales: Sale[];
  sale: Sale | null;
  loading: boolean;
  error: string | null;
  totalCount: number;
}

const initialState: SaleState = {
  sales: [],
  sale: null,
  loading: false,
  error: null,
  totalCount: 0,
};

// API base URL
const API_URL = 'http://localhost:5000/api';

export const fetchSales = createAsyncThunk(
  'sales/fetchAll',
  async (params: { page?: number; pageSize?: number; search?: string } = {}, { rejectWithValue }) => {
    try {
      const { page = 1, pageSize = 10, search = '' } = params;
      const response = await axios.get(`${API_URL}/sales`, {
        params: { page, pageSize, search },
      });
      return response.data;
    } catch (error: any) {
      return rejectWithValue(error.response?.data?.message || 'Failed to fetch sales');
    }
  }
);

export const fetchSaleById = createAsyncThunk(
  'sales/fetchById',
  async (id: number, { rejectWithValue }) => {
    try {
      const response = await axios.get(`${API_URL}/sales/${id}`);
      return response.data;
    } catch (error: any) {
      return rejectWithValue(error.response?.data?.message || 'Failed to fetch sale');
    }
  }
);

export const createSale = createAsyncThunk(
  'sales/create',
  async (saleData: { productId: number; quantity: number; price: number; customerName: string }, { rejectWithValue }) => {
    try {
      const response = await axios.post(`${API_URL}/sales`, saleData);
      return response.data;
    } catch (error: any) {
      return rejectWithValue(error.response?.data?.message || 'Failed to create sale');
    }
  }
);

export const downloadSalesReport = createAsyncThunk(
  'sales/downloadReport',
  async (params: { startDate?: string; endDate?: string }, { rejectWithValue }) => {
    try {
      const response = await axios.get(`${API_URL}/sales/report`, {
        params,
        responseType: 'blob',
      });
      
      // Create a URL for the blob and trigger download
      const url = window.URL.createObjectURL(new Blob([response.data]));
      const link = document.createElement('a');
      link.href = url;
      link.setAttribute('download', `sales-report-${new Date().toISOString().split('T')[0]}.xlsx`);
      document.body.appendChild(link);
      link.click();
      link.remove();
      
      return { success: true };
    } catch (error: any) {
      return rejectWithValue(error.response?.data?.message || 'Failed to download report');
    }
  }
);

const saleSlice = createSlice({
  name: 'sales',
  initialState,
  reducers: {
    clearSaleError: (state) => {
      state.error = null;
    },
    clearCurrentSale: (state) => {
      state.sale = null;
    },
  },
  extraReducers: (builder) => {
    builder
      // Fetch all sales
      .addCase(fetchSales.pending, (state) => {
        state.loading = true;
        state.error = null;
      })
      .addCase(fetchSales.fulfilled, (state, action: PayloadAction<any>) => {
        state.loading = false;
        state.sales = action.payload.data;
        state.totalCount = action.payload.totalCount || action.payload.data.length;
      })
      .addCase(fetchSales.rejected, (state, action) => {
        state.loading = false;
        state.error = action.payload as string;
      })
      // Fetch sale by ID
      .addCase(fetchSaleById.pending, (state) => {
        state.loading = true;
        state.error = null;
      })
      .addCase(fetchSaleById.fulfilled, (state, action: PayloadAction<any>) => {
        state.loading = false;
        state.sale = action.payload.data;
      })
      .addCase(fetchSaleById.rejected, (state, action) => {
        state.loading = false;
        state.error = action.payload as string;
      })
      // Create sale
      .addCase(createSale.pending, (state) => {
        state.loading = true;
        state.error = null;
      })
      .addCase(createSale.fulfilled, (state) => {
        state.loading = false;
      })
      .addCase(createSale.rejected, (state, action) => {
        state.loading = false;
        state.error = action.payload as string;
      });
  },
});

export const { clearSaleError, clearCurrentSale } = saleSlice.actions;
export default saleSlice.reducer;