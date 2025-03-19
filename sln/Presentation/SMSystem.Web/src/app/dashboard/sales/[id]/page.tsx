'use client';

import { useEffect } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { RootState, AppDispatch } from '@/redux/store';
import { fetchSaleById, clearCurrentSale } from '@/redux/slices/saleSlice';
import Link from 'next/link';

export default function SaleDetailPage({ params }: { params: { id: string } }) {
  const dispatch = useDispatch<AppDispatch>();
  const { sale, loading, error } = useSelector((state: RootState) => state.sales);
  const saleId = parseInt(params.id);

  useEffect(() => {
    dispatch(fetchSaleById(saleId));
    
    return () => {
      dispatch(clearCurrentSale());
    };
  }, [dispatch, saleId]);

  if (loading) {