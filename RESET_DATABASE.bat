@echo off
setlocal
for /r %%F in (cafe_manager.db) do (
  echo Deleting %%F
  del /f /q "%%F"
)
echo Database da duoc xoa. Chay lai ung dung de tao du lieu mau.
pause
