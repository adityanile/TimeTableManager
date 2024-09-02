import { SubjectData } from "@/app/types";
import { NextResponse } from "next/server";

export async function POST(request: Request) {
  const { Day, TeacherName } = await request.json();

  if (!Day || !TeacherName)
    return NextResponse.json({ status: "Fail", msg: "Invalid Params" });

  return NextResponse.json({ Day, TeacherName });
}
