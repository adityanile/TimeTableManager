import { SubjectData } from "@/app/types";
import { NextResponse } from "next/server";
import prisma from "@/lib/prisma";

export async function POST(request: Request) {
  const { Day, TeacherName } = await request.json();

  if (!Day || !TeacherName)
    return NextResponse.json({ status: "Fail", msg: "Invalid Params" });

  const subjects = await prisma.subjects.findMany({
    where: {
      teachername: TeacherName,
      dayofweek: Day,
    },
    orderBy: {
      id: "asc",
    },
  });

  if (subjects.length == 0)
    return NextResponse.json({ status: "success", msg: "No Data Found" });

  return NextResponse.json(subjects);
}
