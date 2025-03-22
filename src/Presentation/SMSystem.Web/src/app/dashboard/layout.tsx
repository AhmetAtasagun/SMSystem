'use client';

import { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import Link from 'next/link';
import { useSelector, useDispatch } from 'react-redux';
import { RootState, AppDispatch } from '@/redux/store';
import { logout } from '@/redux/slices/authSlice';

export default function DashboardLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  const { isAuthenticated } = useSelector((state: RootState) => state.auth);
  const router = useRouter();
  const dispatch = useDispatch<AppDispatch>();

  useEffect(() => {
    if (!isAuthenticated) {
      router.push('/login');
    }
  }, [isAuthenticated, router]);

  const handleLogout = () => {
    dispatch(logout());
    router.push('/login');
  };

  if (!isAuthenticated) {
    return null; // Don't render anything while redirecting
  }

  return (
    <div className="min-h-screen flex flex-col">
      <header className="bg-primary-700 text-white shadow-md">
        <div className="container mx-auto px-4 py-3 flex justify-between items-center">
          <Link href="/dashboard" className="text-xl font-bold">SM System</Link>
          <nav className="flex space-x-4 items-center">
            <Link href="/dashboard/products" className="hover:text-primary-200">Ürünler</Link>
            <Link href="/dashboard/categories" className="hover:text-primary-200">Kategoriler</Link>
            <Link href="/dashboard/sales" className="hover:text-primary-200">Satışlar</Link>
            <button 
              onClick={handleLogout}
              className="btn btn-secondary text-sm py-1 px-3">
              Çıkış Yap
            </button>
          </nav>
        </div>
      </header>
      <main className="flex-grow container mx-auto px-4 py-6">
        {children}
      </main>
      <footer className="bg-gray-100 border-t">
        <div className="container mx-auto px-4 py-3 text-center text-gray-600 text-sm">
          &copy; {new Date().getFullYear()} SM System - Tüm hakları saklıdır.
        </div>
      </footer>
    </div>
  );
}